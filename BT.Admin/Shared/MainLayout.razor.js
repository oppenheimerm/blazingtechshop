

var MenuBar, SideBar, SwitchMode;

export function initSidebar(menuBar, sideBar, switchMode) {
    MenuBar = menuBar;
    SideBar = sideBar;
    SwitchMode = switchMode;
}

export function menuBarClick() {
    MenuBar.addEventListener('click', function () {
        SideBar.classList.toggle('hide');
    })
}

export function themeModeToggle() {
    
    var app = document.getElementById("app").className;

    //  check for exactly an empty string, compare for strict
    //  equality against "" using the === operator:
    if (app === "") {
        document.body.classList.add('dark');
        console.log("In dark mode");
    } else {
        document.body.classList.remove('dark');
        console.log("In light mode");
    }
}

