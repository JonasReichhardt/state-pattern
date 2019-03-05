import { Tokenizer } from "./Tokenizer";
import { SQLParser } from "./Parser";

let nodes: HTMLElement[] = new Array<HTMLElement>();

window.addEventListener("DOMContentLoaded", main);

async function main(): Promise<void> {
	document.getElementById("parse").addEventListener("click", parse);
	getNodes();

	setTimeout(() => {
		nodes[0].setAttribute("stroke","red");
		setTimeout(() => {
			nodes[0].setAttribute("stroke","black");
			nodes[1].setAttribute("stroke","red");
		}, 1000);
	}, 1000);
}

function getNodes(): void {
	nodes.push(document.getElementById("startNode"));
	nodes.push(document.getElementById("node1"));
}

function parse(): void {
	let input: string = (<HTMLInputElement>document.getElementById("input")).value;
	// let attr = document.getElementById("attr").value;

	// console.log(attr);

	let rows: string[] = ["a", "b"];
	/*for(var i=0; i<attr.length;i++){
		rows.push(at.value);
	}*/

	let tokenizer: Tokenizer = new Tokenizer(input);
	let tokens: string[] = tokenizer.tokenize();

	var parser: SQLParser = new SQLParser(tokens, rows);
	parser.parse();
}