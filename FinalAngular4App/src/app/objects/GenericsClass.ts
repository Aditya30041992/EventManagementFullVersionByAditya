

class Repository<T> {
    value : T;
    setValue(value : T) {
        this.value = value;
    }
    getValue() : T {
        return this.value;
    }
}

var gen1 = new Repository<string>();
gen1.setValue("Hello World");
let result12:string=gen1.getValue();

var gen2 = new Repository<number>();
gen2.setValue(1);
let result13=gen2.getValue();

var gen3 = new Repository<boolean>();
gen3.setValue(true);
let result34=gen3.getValue();

console.log(result12);
console.log(result13);
console.log(result34);

