let nodes = new Array();

window.addEventListener("DOMContentLoaded", main);
document.getElementById("parse").addEventListener("click", parse);

function main() {
    getNodes();
    
}
function getNodes() {
    nodes.push(document.getElementById("startNode"));
    nodes.push(document.getElementById("node1"));
    nodes.push(document.getElementById("node2"));
}
function parse() {
    setTimeout(() => {
        nodes[0].setAttribute("stroke", "red");
        setTimeout(() => {
            nodes[0].setAttribute("stroke", "black");
            nodes[1].setAttribute("stroke", "red");
            setTimeout(()=>{
                nodes[1].setAttribute("stroke","black")
                nodes[2].setAttribute("stroke","red");
                setTimeout(()=>{
                    nodes[2].setAttribute("stroke","black")
                },2000)
            },2000)
        }, 2000);
    }, 1000);
}
