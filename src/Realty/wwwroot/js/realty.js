$(document).ready(function() {

   var updateTotalSale = function () {
      var price = $("#purchase-price").text();
      var priceVal = Number(price.replace(/[^0-9\.]+/g, ""));
      var realtorFee = Number($("#RealtorFee").val());
      var total = priceVal + realtorFee;
      var totalStr = "$ " + total.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');

      $("#total-sale").html(totalStr);
   }
   updateTotalSale();

   $("#RealtorFee").on("change paste keyup", function () {
      updateTotalSale();
   });

});
