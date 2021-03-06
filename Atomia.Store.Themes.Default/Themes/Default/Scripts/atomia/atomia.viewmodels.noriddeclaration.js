﻿/* jshint -W079 */
var Atomia = Atomia || {};
Atomia.ViewModels = Atomia.ViewModels || {};
/* jshint +W079 */

(function (exports, _, ko) {
    'use strict';

    /** Create a Knockout view model for norid declaration data. */
    function NoridDeclarationModel(cart, account) {
        var self = this;

        self.noridSignedName = ko.observable('');
        self.acceptedDeclaration = ko.observable(false);

        self.showNoridDeclaration = ko.pureComputed(function showNoridDeclaration() {
            var indexes = self.getNoridDomainIndexes();
            if (indexes.length > 0) {
                var attr = cart.cartItems()[indexes[0]].attrs["domainRegistrySpecificAttributes"];
                if (attr !== null && attr !== undefined && attr !== "") {
                    var obj = JSON.parse(attr);
                    self.noridSignedName(obj.AcceptName);
                    self.acceptedDeclaration(true);
                }

                return true;
            }
            return false;
        });

        self.getNoridDomainIndexes = function getNoridDomainIndexes() {
            var indexes = [];
            for (var i = 0; i < cart.cartItems().length; i++) {
                var prodvalue = cart.cartItems()[i].attrs.productvalue;
                if (prodvalue !== null && prodvalue !== undefined && prodvalue.toLowerCase() === ".no") {
                    indexes.push(i);
                }
            }
            return indexes;
        };

        self.noridSignedName.subscribe(function (newValue) {
            var indexes = self.getNoridDomainIndexes();
            if (newValue !== null && newValue !== undefined && newValue !== "" && self.acceptedDeclaration()) {
                for (var i = 0; i < indexes.length; i++) {
                    cart.cartItems()[indexes[i]].attrs["DomainRegistrySpecificAttributes"] = '{"AcceptName": "' + newValue + '", "AcceptDate": "' + self.getTime(false) + '", "AcceptVersion": "2.0" }';
                }
            } else {
                for (var i = 0; i < indexes.length; i++) {
                    delete cart.cartItems()[indexes[i]].attrs["DomainRegistrySpecificAttributes"];
                    delete cart.cartItems()[indexes[i]].attrs["domainRegistrySpecificAttributes"];
                }
            }

            cart.recalculate();
        });

        self.acceptedDeclaration.subscribe(function (newValue) {
            var indexes = self.getNoridDomainIndexes();
            if (newValue && self.noridSignedName() !== "") {
                for (var i = 0; i < indexes.length; i++) {
                    cart.cartItems()[indexes[i]].attrs["DomainRegistrySpecificAttributes"] = '{"AcceptName": "' + self.noridSignedName() + '", "AcceptDate": "' + self.getTime(false) + '", "AcceptVersion": "2.0" }';
                }
            } else {
                for (var i = 0; i < indexes.length; i++) {
                    delete cart.cartItems()[indexes[i]].attrs["DomainRegistrySpecificAttributes"];
                    delete cart.cartItems()[indexes[i]].attrs["domainRegistrySpecificAttributes"];
                }
            }

            cart.recalculate();
        });

        self.openDeclaration = function () {
            var companyName = $("#MainContact_CompanyInfo_CompanyName").val();
            companyName = companyName === undefined ? "" : companyName;
            var companyNumber = account.mainContactIsCompany() ? $("#MainContact_CompanyInfo_IdentityNumber").val() : $("#MainContact_IndividualInfo_IdentityNumber").val();
            companyNumber = companyNumber === undefined ? "" : companyNumber;

            var noDomains = [];
            var indexes = self.getNoridDomainIndexes();
            for (var i = 0; i < indexes.length; i++) {
                noDomains.push(cart.cartItems()[indexes[i]].attrs["domainName"]);
            }
            window.open('/Account/NoridTermsOfService?name=' + self.noridSignedName() + '&companyName=' + companyName + '&companyNumber=' + companyNumber + '&domains=' + noDomains.join('|') + '&time=' + self.getTime(true), 'mywindow', 'status=1');
        };

        self.getTime = function getTime(timestamp) {
            var timeprocessed = new Date().toISOString().slice(0, -5) + 'Z';
            if (timestamp) {
                return timeprocessed;
            } else {
                return timeprocessed.slice(0, 10) + ' ' + timeprocessed.slice(11, 19);
            }
        };
    }


    /* Module exports */
    _.extend(exports, {
        NoridDeclarationModel: NoridDeclarationModel
    });

})(Atomia.ViewModels, _, ko);