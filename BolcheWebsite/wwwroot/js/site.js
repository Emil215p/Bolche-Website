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
    alert("Not implemented yet.");
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