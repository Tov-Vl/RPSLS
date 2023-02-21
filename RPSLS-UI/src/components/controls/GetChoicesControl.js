import { Component } from 'react';
import Choices from '../Choices'

export default class GetChoicesControl extends Component {
    constructor(props) {
        super(props);
        this.state = { buttonIsPressed: false, dataIsLoaded: false };

        this.OnDataLoaded = this.OnDataLoaded.bind(this);
    }

    OnDataLoaded() {
        this.setState({ dataIsLoaded: true });
    }

    render() {
        let button;

        button = <button onClick={() => { this.setState({ buttonIsPressed: true }) }}>
            Get all gestures
        </button>;

        return (
            <>
                {!this.state.dataIsLoaded && button}
                {this.state.buttonIsPressed && <Choices OnDataLoaded={this.OnDataLoaded} />}
            </>
        );
    }
}
