angular.module('myApp').component('projectGrid', {

	templateUrl: 'projectGrid/projectGrid.html',
	controller: function ($http) {
		var ctrl = this;

		ctrl.$onInit = function () {
			$http.get('http://localhost:49956/api/project/get')
				.then(function (response) {
					ctrl.projects = response.data;
				})
				.catch(function (response) {
					alert('Oops! Sorry! Something went wrong. Please contact administrator.', response.status, response.data);
				});
		}
	}
});