import { useEffect, useState } from "react";
import LoadingDelayedSpinner from './LoadingDelayedSpinner';

export default function Scoreboard() {
    const [scoreboard, setScoreboard] = useState();
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        populateData()
            .catch(console.error);;
    }, []);

    const populateData = async () => {
        const scoreboardPromise = fetch('getscoreboard');
        const choicesPromise = fetch('choices');

        const scoreboard = await (await scoreboardPromise).json();
        const choices = await (await choicesPromise).json();

        const capitalizeWord = (word) => {
            let res = word.toLowerCase();
            res = res.charAt(0).toUpperCase() + res.slice(1);
            return res
        };

        const choicesDict = Object.fromEntries(choices.id.map((choiceId, i) =>
            [choiceId, capitalizeWord(choices.name[i])]
        ));

        setScoreboard(scoreboard.map(e => ({
            playerOneName: e.player_one_name,
            playerOneGesture: choicesDict[e.player_one_gesture],
            playerTwoName: e.player_two_name,
            playerTwoGesture: choicesDict[e.player_two_gesture],
            result: capitalizeWord(e.results)
        })
        ));

        setLoading(false);
    };

    const renderTable = (scoreboard) => {
        return (
            <table className='table table-bordered table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th rowSpan={2} className='text-center-center'>#</th>
                        <th colSpan={2} className='text-center'>Player 1</th>
                        <th colSpan={2} className='text-center'>Player 2</th>
                        <th rowSpan={2} className='text-center-left'>Result</th>
                    </tr>
                    <tr>
                        <th>Name</th>
                        <th>Gesture</th>
                        <th>Name</th>
                        <th>Gesture</th>
                    </tr>
                </thead>
                <tbody>
                    {scoreboard.map((e, i) =>
                        <tr key={`scoreboardrow-${i}`}>
                            <td className='text-center'>{i + 1}</td>
                            <td>{e.playerOneName}</td>
                            <td>{e.playerOneGesture}</td>
                            <td>{e.playerTwoName}</td>
                            <td>{e.playerTwoGesture}</td>
                            <td>{e.result}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    };

    return (
        <div>
            <h1 id="tabelLabel" >Scoreboard</h1>
            {loading
                ? <LoadingDelayedSpinner delay={200} />
                : renderTable(scoreboard)}
        </div>
    )
}
