
var HamburgerButton, CloseHamburgerButton, NavResponsiveWrap;

export function initMobileNav(hamburgerButton, closeHamburgerButton, navResponsiveWrap) {
    HamburgerButton = hamburgerButton;
    CloseHamburgerButton = closeHamburgerButton;
    NavResponsiveWrap = navResponsiveWrap;
}


export function hamburgerArrowButtonClick() {
    // hide hamburger button
    //  material-symbols-sharp
    //console.log("Hamburger button was clicked!");
    HamburgerButton.classList.add("display-none");
    NavResponsiveWrap.classList.add("show-mobile-menu");
    //  Show Close Button
    showCloseButton();
}

export function closeMobileMenuButtonClicked() {
    //  hide close button
    CloseHamburgerButton.classList.add("display-none");
    NavResponsiveWrap.classList.remove("show-mobile-menu");
    //  Show Hamburger Button
    showHamburgerButton();
}

export function hideMobileMenu() {
    //  hide close button
    CloseHamburgerButton.classList.add("display-none");
    NavResponsiveWrap.classList.remove("show-mobile-menu");
    //  Show Hamburger Button
    showHamburgerButton();
}

function showCloseButton() {
    CloseHamburgerButton.classList.remove("display-none");
    // hide hamburger button
    hideHamburgerButton();
}

function showHamburgerButton() {
    HamburgerButton.classList.remove("display-none");
    hideCloseButton();
}

function hideHamburgerButton() {
    HamburgerButton.classList.add("display-none");
}

function hideCloseButton() {
    CloseHamburgerButton.classList.add("display-none");
}