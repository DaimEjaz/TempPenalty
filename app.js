const colArr = new Array();
const rowArr = new Array();
const blockArr = new Array();
const gridSize = 9;
const blockSize = 3;
const digitSet = new Set();
const solutionArr = new Array();

//adding digits to set 

for (let i = 1; i < 10; i++) {
    digitSet.add(i);
    rowArr.push(new Set());
    colArr.push(new Set());
    blockArr.push(new Set());
    solutionArr.push(new Array());
}


for (let row = 0; row < gridSize; row++) {
    for (let col = 0; col < gridSize; col++) {
        rowArr[row].add(col + 1);
        colArr[row].add(col + 1);
        blockArr[row].add(col + 1);
    }
}

const arr = Array.from(digitSet);
// blockArr[3].add(4);
console.log(blockArr);
console.log(colArr);
let loopCount = 0;

function choose(choices) {
    if (choices.length > 0) {
        let index = Math.floor(Math.random() * choices.length);
        return choices[index];
    }

}

function fillDiagonals() {
    for (let block = 0; block < gridSize; block += 4) {
        // for (let col = 0; col < gridSize; col++) {
        //     let currentRow = rowArr[row];
        //     let currentCol = colArr[col];
        //     let blockIndex = Math.floor(row / 3) + Math.floor(col / 3);
        //     let blockRow = Math.floor(row / 3);
        //     let blockIncrement = 3 * blockRow;
        //     blockIndex = blockIndex - blockRow + blockIncrement;
        //     let currentBlock = blockArr[blockIndex];


        //     const arr = Array.from(currentBlock)
        //     let currentValue;
        //     let chooseAgain = true;


        //     if (blockIndex === 0 || blockIndex === 4 || blockIndex === 8) {
        //         currentValue = choose(arr)
        //         if (currentRow.has(currentValue) && currentCol.has(currentValue) && currentBlock.has(currentValue)) {
        //             solutionArr[row][col] = currentValue;
        //             console.log(blockArr);
        //             console.log(blockIndex);
        //             // console.log(currentValue);
        //             console.log(colArr);
        //             console.log(rowArr);
        //             console.log(solutionArr);
        //             rowArr[row].delete(currentValue)
        //             colArr[col].delete(currentValue)
        //             blockArr[blockIndex].delete(currentValue)


        //         }

        //     }

        // }
        console.log(block);
        fillBox(block, block);


    }
}

function fillBox(blockRow, blockCol) {
    let blockIndex = blockRow
    let rowComp;
    let colComp;

    if(blockRow ==0 || blockCol == 0){
        rowComp = blockRow
        colComp = blockCol
        blockRow ++;
        blockCol ++;
    }else{
        rowComp = blockRow - 1
        colComp = blockCol - 1
    }
    for (let row = blockRow - 1; row < rowComp + blockSize; row++) {
        for (let col = blockCol - 1; col < colComp + blockSize; col++) {
            let currentRow = rowArr[row];
            let currentCol = colArr[col];
            console.log(currentCol);
            currentValue = choose(arr);
            let currentBlock = blockArr[blockIndex];
            // if (currentBlock.has(currentValue)) {
            //     solutionArr[row][col] = currentValue;
            //     console.log(blockArr);
            //     console.log(blockIndex);
            //     console.log(currentValue);
            //     console.log(colArr);
            //     console.log(rowArr);
            //     console.log(solutionArr);
            //     rowArr[row].delete(currentValue)
            //     colArr[col].delete(currentValue)
            //     blockArr[blockIndex].delete(currentValue)
            //     loopCount++;


            //     chooseAgain = false;
            // }}
        }}
    }




fillDiagonals()
