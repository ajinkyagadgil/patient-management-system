import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'layoutDesign', pathMatch: 'full' },
  { path: 'layoutDesign', loadChildren: () => import('./modules/layout-design/layout-design.module').then(mod => mod.LayoutDesignModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
