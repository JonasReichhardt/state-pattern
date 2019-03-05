import { startState, state1, state2, state3, state4, state5, state6, state7, endState, errorState, IState } from "./States";

export class SQLParser {
	tokens: string[];
	attr: string[];
	states: IState[];
	state: IState;

	constructor(tokens: string[], attrs: string[]) {
		if (tokens != null && tokens.length > 0) {
			this.tokens = tokens;
		} else {
			console.error("parser error: empty token");
		}

		if (attrs != null) {
			this.attr = attrs;
		} else {
			console.log("parser error: attributes undefined");
		}

		this.states = new Array<IState>();
		this.states[0] = startState;
		this.states[1] = state1;
		this.states[2] = state2;
		this.states[3] = state3;
		this.states[4] = state4;
		this.states[5] = state5;
		this.states[6] = state6;
		this.states[7] = state7;
		this.states[8] = endState;
		this.states[9] = errorState;

		this.state = this.states[0];
	}

	parse(): void {
		for (let i: number = 0; i < this.tokens.length; i++) {
			console.log("parsing " + this.tokens[i]);
			this.state.parse(this, this.tokens[i], this.attr);
		}
	}

	changeState(stateIndex: number): void {
		this.state = this.states[stateIndex];
		console.log("new state" + stateIndex);
	}

	reset(): void {
		this.tokens = null;
		this.state = this.states[0];
	}
}