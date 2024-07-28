function validate(id, min, max) {
    let inp = document.getElementById(id);
    inp.value = inp.value < min ? min : inp.value > max ? max : inp.value;
}