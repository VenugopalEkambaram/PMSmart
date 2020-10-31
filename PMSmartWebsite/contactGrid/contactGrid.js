angular.module('myApp').component('contactGrid', {
	templateUrl: 'contactGrid/contactGrid.html',
	controller: function ($http) {
		var ctrl = this;

		ctrl.$onInit = function () {
			$http.get('http://localhost:49956/api/contact')
				.then(function (response) {
					ctrl.contacts = response.data;
				})
				.catch(function (response) {
					alert('Oops! Sorry! Something went wrong. Please contact administrator.', response.status, response.data);
				});
		};
	}
});