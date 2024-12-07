window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
}

window.AnimateStandard = () => {
    const element = document.getElementById("newStandard");

    element.classList.remove("animation");
    void element.offsetWidth;
    element.classList.add("animation");
}

window.AnimateExtended = () => {
    const element = document.getElementById("newExtended");

    element.classList.remove("animation");
    void element.offsetWidth;
    element.classList.add("animation");
}
export function PressedLeft() {
    DotNet.invokeMethodAsync('Blazor2048Test', 'Left');
}

export function PressedRight() {
    DotNet.invokeMethodAsync('Blazor2048Test', 'Right');
}

export function PressedUp() {
    DotNet.invokeMethodAsync('Blazor2048Test', 'Up');
}

export function PressedDown() {
    DotNet.invokeMethodAsync('Blazor2048Test', 'Down');
}

export function AddHandlers() {
    document.addEventListener("keydown", KeyPressed);
}
export function KeyPressed(e) {

    if (e.code == "ArrowLeft" || e.code == "KeyA") {
        PressedLeft();
    }
    if (e.code == "ArrowRight" || e.code == "KeyD") {
        PressedRight();
    }
    if (e.code == "ArrowUp" || e.code == "KeyW") {
        PressedUp();
    }
    if (e.code == "ArrowDown" || e.code == "KeyS") {
        PressedDown();
    }
}

export function PressedLeft2() {
    DotNet.invokeMethodAsync('Blazor2048Test', 'LeftExt');
}

export function PressedRight2() {
    DotNet.invokeMethodAsync('Blazor2048Test', 'RightExt');
}

export function PressedUp2() {
    DotNet.invokeMethodAsync('Blazor2048Test', 'UpExt');
}

export function PressedDown2() {
    DotNet.invokeMethodAsync('Blazor2048Test', 'DownExt');
}

export function AddHandlers2() {
    document.addEventListener("keydown", KeyPressed2);
}
export function KeyPressed2(e) {
    console.log(e.code);

    if (e.code == "ArrowLeft" || e.code == "KeyA") {
        PressedLeft2();
    }
    if (e.code == "ArrowRight" || e.code == "KeyD") {
        PressedRight2();
    }
    if (e.code == "ArrowUp" || e.code == "KeyW") {
        PressedUp2();
    }
    if (e.code == "ArrowDown" || e.code == "KeyS") {
        PressedDown2();
    }
}




