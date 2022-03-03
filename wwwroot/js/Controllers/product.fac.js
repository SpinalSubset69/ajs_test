(() => {
  angular.module("mainModule").factory("productFactory", ($http) => {
    function saveProduct(product) {
      return $http.post("/product/saveproduct", product);
    }

    function listProducts() {
      return $http.get("/product/List");
    }

    function uploadImage(userId, image) {
      return $http.post(`/product/UploadImage/${userId}`, image);
    }
    return {
      saveProduct,
      listProducts,
      uploadImage,
    };
  });
})();
