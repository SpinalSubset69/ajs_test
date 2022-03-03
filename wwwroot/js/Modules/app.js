(() => {
  angular
    .module("mainModule", ["ngMaterial"])
    .config(function ($mdThemingProvider) {
      $mdThemingProvider
        .theme("default")
        .primaryPalette("red")
        .accentPalette("orange");
    });
})();
