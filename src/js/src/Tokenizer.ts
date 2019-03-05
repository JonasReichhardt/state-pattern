export class Tokenizer {
	input: string;

	constructor(input: string) {
		if (input != null && input !== "") {
			this.input = input;
		} else {
			this.input = "";
		}
	}

	tokenize(): string[] {
		let tokens: string[] = this.input.split(" ");
		let ret: string[] = [];

		for (let i: number = 0; i < tokens.length; i++) {
			if (tokens[i].includes(",")) {
				let splitted: string[] = tokens[i].split(",");
				for (let j: number = 0; j < splitted.length; j++) {
					ret.push(splitted[j]);
				}
			} else {
				ret.push(tokens[i]);
			}
		}

		console.log("tokens: " + ret);
		return ret;
	}
}