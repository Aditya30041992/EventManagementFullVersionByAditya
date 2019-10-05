function processData(arg: number): number {
    return arg;
}
//var result=processData(34);
//console.log(result);

function processAnyData(arg: any): any {
    return arg;
}

//var result=processData("Ravi Tambade");
//console.log("Any Data" +result);



function processGenericsData<T>(arg: T): T {
    return arg;
}



//let result = processGenericsData<string>("Ravi Tambade");  // type of output will be 'string'
//let result=processGenericsData<number>(45);
let result=processGenericsData("Ravi Tambade");

 
console.log("Generics Data  :" +result);