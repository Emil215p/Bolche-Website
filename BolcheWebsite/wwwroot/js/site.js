// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
    function toggleON(elementId) {
      const element = document.getElementById(elementId);
    element.style.display = "block";
    }

    function toggleOFF(elementId) {
      const element = document.getElementById(elementId);
    element.style.display = "none";
}

    function SearchForLetterShift() {
    currentFunction = newFunction;
    alert("Function changed!");

    function SearchForGeneralShift() {
        currentFunction = newFunction;
        alert("Function changed!");
    }
function SearchThing() {
    // First, we need to declare our variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("BolcheTabel");
    tr = table.getElementsByTagName("tr");

    // Then, we need to Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function SearchByLetter() {
    document.getElementById('myInput').addEventListener('input', function () {
        let filter = this.value.toUpperCase();
        let table = document.getElementById('BolcheTabel');
        let tr = table.getElementsByTagName('tr');

        for (let i = 1; i < tr.length; i++) { // Start from 1 to skip the header row
            let td = tr[i].getElementsByTagName('td')[0]; // Assuming you want to filter by the first column
            if (td) {
                let txtValue = td.textContent || td.innerText;
                if (txtValue.toUpperCase().startsWith(filter)) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    });
}