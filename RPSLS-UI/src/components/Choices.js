import { Component } from 'react';
import LoadingDelayedSpinner from './LoadingDelayedSpinner';

export default class Choices extends Component {
    static displayName = Choices.name;

    constructor(props) {
        super(props);
        this.state = { choice: { ids: [], names: [] }, loading: true };
        this.mounted = false;
        this.componentDidMount = this.componentDidMount.bind(this)
    }

    componentDidMount() {
        if (this.mounted) {
            // already mounted previously
            return;
        }
        this.mounted = true;
        this.populateData();
    }

    static renderTable(state) {
        return (
            <table className='table table-bordered table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                    {state.choice.ids.map((_, i) =>
                        <tr key={state.choice.ids[i]}>
                            <td>{state.choice.ids[i]}</td>
                            <td>{state.choice.names[i]}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let content = this.state.loading
            ? <LoadingDelayedSpinner delay={200} />
            : Choices.renderTable(this.state);

        return (
            <div>
                <h4 id="tabelLabel">Possible gestures</h4>
                {content}
            </div>
        );
    }

    async populateData() {
        const response = await fetch('choices');
        const data = await response.json();
        this.setState({ choice: { ids: data.id, names: data.name }, loading: false });
        this.props.OnDataLoaded();
    }
}
