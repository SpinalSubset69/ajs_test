(() => {
  angular
    .module("mainModule", ["ngMaterial"])
    .controller("mainCtrl", [
      "$scope",
      "$log",
      "productFactory",
      "$mdToast",
      "$mdSidenav",
      mainCtr,
    ]);

  function mainCtr($scope, $log, productFactory, $mdToast, $mdSidenav) {
    getProducts();
    $scope.openSideNav = () => $mdSidenav("sideNav").open();
    $scope.product = { image: "" };
    $scope.file = { name: "", content: "" };

    function showToast(message) {
      $mdToast.show(
        $mdToast
          .simple()
          .textContent(message)
          .position("top right")
          .hideDelay(3000)
      );
    }

    function postAddCard(user) {
      $mdSidenav("sideNav").close();
      $scope.product = {};
      $scope.file = {};
    }

    function getProducts() {
      productFactory
        .listProducts()
        .then(({ data }) => ($scope.products = data));
    }

    //SELECTED IMAGE
    $scope.fileSelected = (args) => {
      const type = args.files[0].type;
      if (
        !type.includes("png") &&
        !type.includes("jpg") &&
        !type.includes("jpeg")
      ) {
        showToast("Can only select iamges");
        return;
      }
      getbase64(args.files[0]).then((res) => {
        $scope.file.content = res;
        $scope.file.name = args.files[0].name;
        $scope.product.image = args.files[0].name;
      });
    };

    $scope.createProduct = () => {
      $scope.product.createdAt = new Date();

      if (!$scope.file.content) {
        showToast("Select an Image");
        return;
      }

      if (
        !$scope.product.name ||
        !$scope.product.price ||
        !$scope.product.description
      ) {
        showToast("Fill the Form");
        return;
      }
      productFactory
        .saveProduct($scope.product)
        .then(({ data }) => {
          const user = data;
          productFactory
            .uploadImage(user.id, $scope.file)
            .then(({ data }) => {
              postAddCard(user);
              showToast("Product Saved");
            })
            .catch((err) => console.log(err));
        })
        .catch((err) => {
          showToast(err.message);
        });
    };
  }
})();
