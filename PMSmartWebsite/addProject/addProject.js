angular.module('myApp').component('addProject', {
	bindings: {
		onSave: '&'
	},

	templateUrl: 'addProject/addProject.html',
	controller: function ($http) {
		var ctrl = this;

		ctrl.resetMode = function () {
			$http.post('http://localhost:49956/api/project', {
				'Name': ctrl.name,
				'Description': ctrl.description
			})
				.then(function (response) {
					alert('Project added successfully!!!');
					ctrl.onSave();
				})
				.catch(function (response) {
					alert('Oops! Sorry! Something went wrong. Please contact administrator.', response.status, response.data);
				});
		};

	}

});