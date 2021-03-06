import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;
    
    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'aureliadotnet';
        config.map([{
            route: [ '', 'home' ],
            name: 'home',
            settings: { icon: 'home' },
            moduleId: PLATFORM.moduleName('../home/home'),
            nav: true,
            title: 'Home'
        }, {
            route: 'counter',
            name: 'counter',
            settings: { icon: 'education' },
            moduleId: PLATFORM.moduleName('../counter/counter'),
            nav: true,
            title: 'Counter'
        },{
            route: 'login',
            name: 'login',
            settings: { icon: 'education' },
            moduleId: PLATFORM.moduleName('../login/login'),
            nav: true,
            title: 'Login'
        },{
            route: 'register',
            name: 'register',
            settings: { icon: 'education' },
            moduleId: PLATFORM.moduleName('../register/register'),
            nav: true,
            title: 'Register'
        }, {
            route: 'bitcoin',
            name: 'bitcoin',
            settings: { icon: 'education' },
            moduleId: PLATFORM.moduleName('../bitcoin/bitcoin'),
            nav: true,
            title: 'Bitcoin'
        },{
            route: 'fetch-data',
            name: 'fetchdata',
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../fetchdata/fetchdata'),
            nav: true,
            title: 'Fetch data'
        }]);

        this.router = router;
    }
}
