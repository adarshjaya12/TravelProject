export class Home {
    constructor() {
        var inputElement = document.getElementById("autocomplete-text") as HTMLInputElement;
        inputElement.addEventListener('onchange', (e) =>
        {
            e.preventDefault();
            if (e.returnValue != undefined || e.returnValue != "")
            {
                inputElement.style.paddingBottom = "0px";
            }
        })
    }
}