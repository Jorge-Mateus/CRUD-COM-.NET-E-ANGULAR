import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BusinessAreaComponent } from './components/business-area/business-area.component';
import { MarketAreaComponent } from './components/market-area/market-area.component';
import { OperitingunitsComponent } from './components/operitingunits/operitingunits.component';
import { OrganationalstructureComponent } from './components/organationalstructure/organationalstructure.component';
import { TechnologicalareaComponent } from './components/technologicalarea/technologicalarea.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';

const routes: Routes = [
  { path: 'unidadedenegocio', component: BusinessAreaComponent},
  { path: 'areademercado', component: MarketAreaComponent},
  { path: 'unidadeoperacional', component: OperitingunitsComponent},
  { path: 'areatecnologica', component: TechnologicalareaComponent},
  { path: 'organizacaoestrutural', component: OrganationalstructureComponent},
  { path: 'dasharboard', component: DashboardComponent},
  {path: 'perfil', component: PerfilComponent},
  { path: '', redirectTo: 'dasharboard', pathMatch: 'full'},
  { path: '**', redirectTo: 'dasharboard', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
