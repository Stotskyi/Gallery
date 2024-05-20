import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegistrationComponent } from './auth/registration/registration.component';
import { ImageViewComponent } from './image/image-view/image-view.component';
import { ImageUploaderComponent } from './image/image-uploader/image-uploader.component';
import { ImagesViewComponent } from './image/images-view/images-view.component';

export const routes: Routes = [
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'registration',
        component: RegistrationComponent
    },
    {
        path: 'image/getAll',
        component: ImagesViewComponent
    },
    {
        path: 'image/upload',
        component: ImageUploaderComponent
    },
];
