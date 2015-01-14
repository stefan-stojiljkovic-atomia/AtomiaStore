﻿/* jshint -W079 */
var Atomia = Atomia || {};
Atomia.ViewModels = Atomia.ViewModels || {};
/* jshint +W079 */


(function (module, _, ko) {
    'use strict';

    var HostingPackagesItem, HostingPackages;

    HostingPackagesItem = function HostingPackagesItem(productData) {
        _.extend(this, productData);
    };

    HostingPackages = function HostingPackages() {
        this.HostingPackagesItem = HostingPackagesItem;

        this.Products = ko.observableArray();

        _.bindAll(this, 'Init', '_UpdateProducts', 'Load');
    };

    HostingPackages.prototype = {
        Init: function(cart) {
            this._MakeCartItem = cart.MakeCartItem;
        },

        _UpdateProducts: function (products) {
            var self = this;

            _.each(products, function (product) {
                var productToAdd = self._MakeCartItem(new self.HostingPackagesItem(product));

                self.Products.push(productToAdd);
            });
        },

        Load: function (listProductsDataResponse) {
            this._UpdateProducts(listProductsDataResponse.data.CategoryData.Products);
        }
    };
    
    module.HostingPackagesItem = HostingPackagesItem;
    module.HostingPackages = HostingPackages;

})(Atomia.ViewModels, _, ko);