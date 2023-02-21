import { useEffect, useState } from "react";
import LoadingDelayedSpinner from './LoadingDelayedSpinner';

export default function Scoreboard() {
    const [scoreboard, setScoreboard] = useState();
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        populateData()
            .catch(console.error);
    }, [loading]);

    const populateData = async () => {
        const scoreboardPromise = fetch('scoreboard/get');
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
                        <th className='text-center'>Player 1 (You)</th>
                        <th colSpan={2} className='text-center'>Player 2</th>
                        <th rowSpan={2} className='text-center-left'>Result</th>
                    </tr>
                    <tr>
                        <th>Gesture</th>
                        <th>Name</th>
                        <th>Gesture</th>
                    </tr>
                </thead>
                <tbody>
                    {scoreboard.map((e, i) =>
                        <tr key={`scoreboardrow-${i}`}>
                            <td className='text-center'>{i + 1}</td>
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

    const resetScoreboard = () => {
        fetch('scoreboard/reset', { method: 'PUT' })
            .catch(console.error);

        setScoreboard([]);
    }

    const getContent = (loading) => {
        if (loading === true) {
            return <LoadingDelayedSpinner delay={200} />;
        }
        else {
            return (
                <>
                    {scoreboard.length === 0
                        ? <></>
                        : renderTable(scoreboard)}
                    <p>
                        <button onClick={resetScoreboard}>
                            Reset scoreboard
                        </button>
                    </p>
                </>
            )
        }
    }

    return (
        <div>
            <h1 id="tabelLabel" >Scoreboard</h1>
            {getContent(loading)}
        </div>
    )
}
