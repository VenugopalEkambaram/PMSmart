angular.module('myApp').component('addContact', {
	bindings: { onSave: '&' },

	templateUrl: 'addContact/addContact.html',
	controller: function ($http) {
		var ctrl = this;

		ctrl.saveContact = function () {
			$http.post('http://localhost:49956/api/contact',
				{ 'firstName': ctrl.firstName, 'lastName': ctrl.lastName })
				.then(function (response) {
					alert('Contact added successfully!!!');
				})
				.catch(function (response) {
					alert('Oops! Sorry! Something went wrong. Please contact administrator.', response.status, response.data);
				});

			ctrl.onSave();
		};

	}

});