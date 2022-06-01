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
import { MarketAreaDetalhesComponent } from './components/market-area/market-area-detalhes/market-area-detalhes.component';
import { MarketAreaListaComponent } from './components/market-area/market-area-lista/market-area-lista.component';
import { OperitingunitsDetalhesComponent } from './components/operitingunits/operitingunits-detalhes/operitingunits-detalhes.component';
import { OperitingunitsaListaComponent } from './components/operitingunits/operitingunits-lista/operitingunitsa-lista.component';
import { TechnologicalareaDetalhesComponent } from './components/technologicalarea/technologicalarea-detalhes/technologicalarea-detalhes.component';
import { TechnologicalareaListaComponent } from './components/technologicalarea/technologicalarea-lista/technologicalarea-lista.component';
import { OrganationalstructureaDetalhesComponent } from './components/organationalstructure/organationalstructurea-detalhes/organationalstructurea-detalhes.component';
import { OrganationalstructureaListaComponent } from './components/organationalstructure/organationalstructurea-lista/organationalstructurea-lista.component';

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
  { path: 'areademercado', redirectTo: 'areademercado/lista'},
  { path: 'areademercado', component: MarketAreaComponent,
    children: [
      {path:  'detalhe/:id', component: MarketAreaDetalhesComponent},
      {path: 'detalhes', component: MarketAreaDetalhesComponent},
      {path: 'lista', component: MarketAreaListaComponent},
    ]
  },

  { path: 'filial', redirectTo: 'filial/lista'},
  { path: 'filial', component: OperitingunitsComponent,
    children: [
      {path: 'detalhe/:id', component: OperitingunitsDetalhesComponent},
      {path: 'detalhes', component: OperitingunitsDetalhesComponent},
      {path: 'lista', component: OperitingunitsaListaComponent},
    ]
  },
  { path: 'areatecnologica', redirectTo: 'areatecnologica/lista'},
  { path: 'areatecnologica', component: TechnologicalareaComponent,
    children: [
      {path: 'detalhe/:id', component: TechnologicalareaDetalhesComponent},
      {path: 'detalhes', component: TechnologicalareaDetalhesComponent},
      {path: 'lista', component: TechnologicalareaListaComponent},
    ]
  },
  { path: 'organizacaoestrutural', redirectTo: 'organizacaoestrutural/lista'},
  { path: 'organizacaoestrutural', component: OrganationalstructureComponent,
    children: [
      {path: 'detalhe/:id', component: OrganationalstructureaDetalhesComponent},
      {path: 'detalhe', component: OrganationalstructureaDetalhesComponent},
      {path: 'lista', component: OrganationalstructureaListaComponent},
    ]
    },
  { path: 'dasharboard', component: DashboardComponent},
  { path: '', redirectTo: 'dasharboard', pathMatch: 'full'},
  { path: '**', redirectTo: 'dasharboard', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
