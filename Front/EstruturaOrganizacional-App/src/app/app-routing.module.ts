import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MarketAreaComponent } from './components/market-area/market-area.component';
import { OperitingunitsComponent } from './components/operitingunits/operitingunits.component';
import { OrganationalstructureComponent } from './components/organationalstructure/organationalstructure.component';
import { TechnologicalareaComponent } from './components/technologicalarea/technologicalarea.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { BusinessAreaComponent } from './components/business-area/business-area.component';
import { BusinessAreaDetalhesComponent } from './components/business-area/business-area-detalhes/business-area-detalhes.component';
import { BusinessAreaListaComponent } from './components/business-area/business-area-lista/business-area-lista.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';

const routes: Routes = [

  { path: 'user', component: UserComponent,
  children: [
    {path: 'login', component: LoginComponent},
    {path: 'registration', component: RegistrationComponent},
  ]
  },
  { path: 'user/perfil', component: PerfilComponent},
  { path: 'unidadedenegocio', redirectTo: 'unidadedenegocio/lista' },
  {
    path: 'unidadedenegocio', component: BusinessAreaComponent,
    children: [
      {path: 'detalhe/:id', component: BusinessAreaDetalhesComponent},
      {path: 'detalhes', component: BusinessAreaDetalhesComponent},
      {path: 'lista', component: BusinessAreaListaComponent},
    ]
  },
  { path: 'areademercado', component: MarketAreaComponent},
  { path: 'unidadeoperacional', component: OperitingunitsComponent},
  { path: 'areatecnologica', component: TechnologicalareaComponent},
  { path: 'organizacaoestrutural', component: OrganationalstructureComponent},
  { path: 'dasharboard', component: DashboardComponent},
  { path: '', redirectTo: 'dasharboard', pathMatch: 'full'},
  { path: '**', redirectTo: 'dasharboard', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
