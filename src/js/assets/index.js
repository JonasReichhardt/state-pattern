import { Tokenizer } from "./Tokenizer.js";
import { SQLParser } from "./Parser.js";

var nodes = [];

window.addEventListener("DOMContentLoaded", main);

async function main(){
	document.getElementById("parse").addEventListener("click",parse);
	getNodes();

	setTimeout(() => {
		nodes[0].setAttribute("stroke","red");
		setTimeout(() => {
			nodes[0].setAttribute("stroke","black");
			nodes[1].setAttribute("stroke","red");
		}, 1000);
	}, 1000);
}

function getNodes(){
	nodes.push(document.getElementById("startNode"));
	nodes.push(document.getElementById("node1"));
}

function parse(){
	var input = document.getElementById("input").value;
	var attr = document.getElementById("attr").nodeValue;

	for(var at in attr){
		console.log(at.value);
	}

	var tokenizer = new Tokenizer(input, attr);
	var tokens = tokenizer.tokenize();
	
	var parser = new SQLParser(tokens);
	parser.parse();
}