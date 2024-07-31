let currentSearchMode = 'none'; // Search mode is set to none by default.

function toggleON() {
    document.getElementById("BolcheTabel").style.display = "block";
}

function toggleOFF() {
    document.getElementById("BolcheTabel").style.display = "none";
}

function SearchForLetterShift() {
    currentSearchMode = 'letter';
    alert("Search mode changed to initial letter!");
}

function SearchForGeneralShift() {
    currentSearchMode = 'general';
    alert("Search mode changed to general search!");
}

function SetColor() {
    document.getElementById("BolcheTabel").style.display = "block";
    const input = document.getElementById("colors");
    const selectedColor = input.value;

    const table = document.getElementById("BolcheTabel");
    const tr = table.getElementsByTagName("tr");

    for (let i = 0; i < tr.length; i++) {
        const tdColor = tr[i].getElementsByTagName("td")[1];
        const tdName = tr[i].getElementsByTagName("td")[0];

        if (tdColor && tdName) {
            const rowColor = tdColor.textContent || tdColor.innerText;
            const rowName = tdName.textContent || tdName.innerText;

            if (rowColor === selectedColor || rowName.toUpperCase().includes(input.value.toUpperCase())) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function SearchThing() {
    const input = document.getElementById("myInput");
    const filter = input.value.toUpperCase();
    const table = document.getElementById("BolcheTabel");
    const tr = table.getElementsByTagName("tr");

    for (let i = 0; i < tr.length; i++) {
        const td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            const txtValue = td.textContent || td.innerText;
            if (currentSearchMode === 'letter') {
                if (txtValue.toUpperCase().startsWith(filter)) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            } else {
                tr[i].style.display = "";
            }
            if (currentSearchMode === 'general') {
                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
    if (currentSearchMode === 'none') {
        alert("Vælg søgekriterier eller klik på Vis alle.");
    }
}
// Ensure bolcheData is defined before this point
if (typeof bolcheData == 'undefined') {
    console.error("bolcheData is not defined");
}


// populate element if they exist
if (document.getElementById("colors")) {

    let uniqueColors = {};

    // Filter out non-unique colors
    let filteredArray = bolcheData.filter((bolche) => {
        let color = bolche.farve;
        if (!uniqueColors[color]) {
            uniqueColors[color] = true;
            return true; // Include the first occurrence of each color
        }
        return false; // Exclude subsequent occurrences
    });

    function populateColorOptions() {
        let select = document.getElementById("colors");
        filteredArray.forEach((bolche) => {
            let option = document.createElement("option");
            option.value = bolche.farve;
            option.text = bolche.farve;
            select.appendChild(option);
        });
    }
    populateColorOptions();
}

// populate element if they exist
if (document.getElementById("bolcher")) {
    let uniqueBolcher = {};

    // Filter out non-unique bolcher
    let filteredArrayNames = bolcheData.filter((bolche) => {
        let name = bolche.bolcheNavn;
        if (!uniqueBolcher[name]) {
            uniqueBolcher[name] = true;
            return true; // Include the first occurrence of each bolche
        }
        return false; // Exclude subsequent occurrences
    });

    function populateBolcherOptions() {
        let select = document.getElementById("bolcher");
        filteredArrayNames.forEach((bolche) => {
            let option = document.createElement("option");
            option.value = bolche.bolcheNavn;
            option.text = bolche.bolcheNavn;
            select.appendChild(option);
        });
    }

    populateBolcherOptions();
}

let selectedBolche;
    function SetBolche() {
        let input = document.getElementById("bolcher");
        selectedBolche = input.value;
        console.log(selectedBolche);
        return selectedBolche;
}

function BolcheSubmit() {
    if (typeof selectedBolche !== 'undefined') {
        FromSql("EXECUTE dbo.OrdersWithCustomersOnSpecific {0}", selectedBolche).ToList();
    } else {
        alert("Select a bolche.");
    }
}

console.log("Script Loaded.");