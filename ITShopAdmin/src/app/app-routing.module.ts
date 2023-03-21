import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthLayoutComponent } from './layout/auth-layout/auth-layout.component';
import { BlankLayoutComponent } from './layout/blank-layout/blank-layout.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/auth/login',
    pathMatch: 'full'
  },
  {
    path: 'auth',
    component: BlankLayoutComponent,
    loadChildren: () => import('./modules/auth/auth.module').then(x => x.AuthModule)
  },
  {
    path: 'category',
    component: AuthLayoutComponent,
    loadChildren: () => import('./modules/category/category.module').then(x => x.CategoryModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
