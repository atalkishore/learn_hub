(function () {
   'use strict';
 
    var moviesServices = angular.module('userServices', ['ngResource']);
 
    moviesServices.factory('User', ['$resource',
      function ($resource) {
          return $resource('/api/user/getall', {}, {
              query: { method: 'GET', params: {}, isArray: true }
          });
      }]);
    }
})();