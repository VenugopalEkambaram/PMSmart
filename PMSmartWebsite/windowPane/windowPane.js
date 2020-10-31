angular.module('myApp').component('windowPane', {
	bindings: { title: '@' },

	templateUrl: 'windowPane/windowPane.html',
	controller: function ($state) {
		var ctrl = this;

		ctrl.changeMode = function (mode) {
			if (ctrl.addMode) {
				$state.reload();
			}

			ctrl.addMode = mode;
		};
	}
});