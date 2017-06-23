/* Provide JavaScript */

var START_INDEX = 0;
var WAIT_TIME = 1500;
var cardSelector = ".card";
var cardSelectorFirstFour = ".card:lt(4)";
var opacityString = "opacity" + ":" + " 1;";

/**
 * Add the first few cards slowly as if they're being dealt. Due to time constraints,
 * add the rest of the cards all together.
 */
function setUpShuffleView() {
        fadeIn(START_INDEX);
        $(cardSelector).delay(WAIT_TIME).animate({ "opacity": "1" });
    { result = false; }
}

/**
 * Change the opacity of the cards to visible. This operation should be one at a time.
 * Return a recursive call to the fade in function.
 * @param {any} index This is the current index of the .card class selected array.
 */
function fadeIn(index) {
        $(cardSelectorFirstFour).eq(index).animate({
            "opacity": "1"
        }, function () {
            fadeIn(index + 1);
        });
}



