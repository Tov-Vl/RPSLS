import { useEffect, useState } from "react";
import Dropdown from '../Dropdown';
import PlayWithComputer from '../PlayWithComputer'
import GameResult from '../GameResult'

export default function PlayControl() {
    const [choices, setChoices] = useState();
    const [choice, setChoice] = useState();
    const [gameResult, setGameResult] = useState();
    const [dataLoaded, setDataLoaded] = useState(false);

    useEffect(() => {
        if (dataLoaded)
            return;

        const fetchData = async () => {
            const response = await fetch('choices');
            const data = await response.json();

            const capitalizeWord = (word) => {
                let res = word.toLowerCase();
                res = res.charAt(0).toUpperCase() + res.slice(1);
                return res
            };

            const choices = data.id.map((_, i) => (
                {
                    value: {
                        id: data.id[i],
                        name: data.name[i]
                    },
                    label: capitalizeWord(data.name[i])
                }));

            setChoices(choices);
            setDataLoaded(true);
        }

        fetchData()
            .catch(console.error);
    });

    const getRandomChoice = () => {
        const fetchData = async () => {
            const response = await fetch('choice');
            const data = await response.json();
            const choice = choices.find(x => {
                return x.value.id === data.id;
            });

            setChoice(choice);
        }

        fetchData()
            .catch(console.error);
    };

    return (
        <div>
            <table>
                <tbody>
                    <tr>
                        <td className="table-dropdown">
                            Choose your gesture:
                        </td>
                        <td className="table-dropdown">
                            <Dropdown
                                placeHolder={choice !== undefined ? choice.label : "Select..."}
                                options={choices}
                                onChange={(value) => setChoice(value)}
                            />
                        </td>
                        <td className="table-dropdown">
                            <button onClick={getRandomChoice}>
                                I'm Feeling Lucky!
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
            <PlayWithComputer
                choice={choice}
                onResult={(gameResult) => setGameResult(gameResult)}
            />
            <GameResult
                gameResult={gameResult}
                choices={choices}
            />
        </div>
    );
}