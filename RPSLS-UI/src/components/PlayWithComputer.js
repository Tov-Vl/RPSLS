export default function PlayWithComputer({ choice, onResult }) {
    const playWithComputer = () => {
        const fetchData = async () => {
            const params = {
                player: choice.value.id,
            };
            const options = {
                method: 'POST',
                body: JSON.stringify(params)
            };

            const response = await fetch('play?player=' + choice.value.id, options);
            const result = await response.json();

            onResult(result)
        }

        fetchData()
            .catch(console.error);
    }

    return (
        <>
            <button onClick={playWithComputer} disabled={choice === undefined}>
                Play with computer!
            </button>
        </>
    );
}