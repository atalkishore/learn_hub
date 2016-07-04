(function () {
    'use strict';

    angular
        .module('UserApp')
        .controller('UserController', UserController);

    UserController.$inject = ['$scope', 'User'];

    function UserController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'UserController';

        activate();

        function activate() { }
    }
})();
