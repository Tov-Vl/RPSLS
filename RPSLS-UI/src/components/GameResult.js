import { useEffect, useState } from "react";

export default function GameResult({ gameResult, choices }) {
    const [choiceVerbs, setChoiceVerbs] = useState();
    const [dataInit, setDataInit] = useState();

    useEffect(() => {
        if (dataInit || choices == undefined)
            return;

        let verbs = choices.map((choice, _) => {
            switch (choice.value.name) {
                case 'rock':
                    return [{ winner: 'rock', loser: 'lizard', verb: 'crushes' }, { winner: 'rock', loser: 'scissors', verb: 'crushes' }];
                    break;
                case 'paper':
                    return [{ winner: 'paper', loser: 'rock', verb: 'covers' }, { winner: 'paper', loser: 'spock', verb: 'disproves' }];
                    break;
                case 'scissors':
                    return [{ winner: 'scissors', loser: 'paper', verb: 'cuts' }, { winner: 'scissors', loser: 'lizard', verb: 'decapitates' }];
                    break;
                case 'lizard':
                    return [{ winner: 'lizard', loser: 'spock', verb: 'eats' }, { winner: 'lizard', loser: 'paper', verb: 'poisons' }];
                    break;
                case 'spock':
                    return [{ winner: 'spock', loser: 'scissors', verb: 'smashes' }, { winner: 'spock', loser: 'rock', verb: 'vaporizes' }];
                    break;
                default:
                    return [];
            };
        });

        verbs = verbs.reduce((a, b) => a.concat(b), []);

        setChoiceVerbs(verbs);
        setDataInit(true);
    });

    const capitalizeWord = (word) => {
        let res = word.toLowerCase();
        res = res.charAt(0).toUpperCase() + res.slice(1);
        return res
    };

    const getGameResultDescription = (gameResult) => {
        let result, winner, loser;
        switch (gameResult.results) {
            case 'win':
                winner = gameResult.player;
                loser = gameResult.computer;
                result = 'You win!'
                break;
            case 'lose':
                winner = gameResult.computer;
                loser = gameResult.player;
                result = 'You lose!'
                break;
            default:
                result = 'Tie!';
        };

        let winReason = '';
        if (winner != undefined) {
            const winnerGesture = choices.find(choice => {
                return choice.value.id == winner;
            }).value.name;

            const loserGesture = choices.find(choice => {
                return choice.value.id == loser;
            }).value.name;

            const verb = choiceVerbs.find(verbElem => {
                return verbElem.winner == winnerGesture
            }).verb;

            winReason = ` ${capitalizeWord(winnerGesture)} ${verb} ${capitalizeWord(loserGesture)}!`;
        }

        return `${result}${winReason}`;
    }

    return (
        <>
            {
                gameResult !== undefined
                    ? <p>Result: {getGameResultDescription(gameResult)}</p>
                    : <></>
            }
        </>
    );
}