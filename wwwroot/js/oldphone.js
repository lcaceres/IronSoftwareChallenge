let lastKey = null;
let lastTime = 0;
let repeatCount = 0;
let currentSequence = "";
let justSubmitted = false;
function pressKey(k) {
    const now = Date.now();

    if (justSubmitted && k !== '#' && k !== '*' && k !== '0') {
        clearDisplay();
        justSubmitted = false;
    }

    if (k === "#") {
        $.ajax({
            type: "POST",
            url: "/Home/ProcessKey",
            data: { sequence: currentSequence + "#" },
            success: function (response) {
                document.getElementById("displayResult").value = response.result;
                document.getElementById("displaySequence").value = currentSequence + "#";
                currentSequence += "#";
                justSubmitted = true;
            },
            error: function () {
                alert("Error processing sequence.");
            }
        });
        return;
    }

    if (k === "*" || k === "0") {
        currentSequence += k;
        document.getElementById("displaySequence").value = currentSequence;
        return;
    }

    const elapsed = now - lastTime;
    const isSameKey = (k === lastKey);
    const max = (k === "7" || k === "9") ? 4 : 3;

    if (isSameKey) {
        if (elapsed > 1000) {
            // Insert a space before new group
            currentSequence += " " + k;
            repeatCount = 1;
        } else {
            repeatCount++;
            if (repeatCount > max) {
                // Removing duplicates and consider only sequence
                currentSequence = currentSequence.substring(0, currentSequence.length - max) + k;
                repeatCount = 1;
            } else {
                currentSequence += k;
            }
        }
    } else {
        // New key
        currentSequence += k;
        repeatCount = 1;
    }

    lastKey = k;
    lastTime = now;
    document.getElementById("displaySequence").value = currentSequence;
}

function clearDisplay() {
    document.getElementById('displaySequence').value = '';
    document.getElementById('displayResult').value = '';
    currentSequence = '';
    lastKey = null;
    lastTime = 0;
    repeatCount = 0;
    justSubmitted = false;
}

