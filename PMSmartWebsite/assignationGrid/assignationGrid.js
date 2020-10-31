angular.module('myApp').component('assignationGrid', {

	templateUrl: 'assignationGrid/assignationGrid.html',
	controller: function ($http, $state) {
		var ctrl = this;

		ctrl.$onInit = function () {
			$http.get('http://localhost:49956/api/project/assignationdetails')
				.then(function (response) {
					ctrl.assignationDetails = response.data;
				});
		}

		ctrl.assignContact = function () {
			$state.reload();
		}
	}
});