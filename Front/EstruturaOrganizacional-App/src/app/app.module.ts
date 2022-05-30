import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';

import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppComponent } from './app.component';
import { NavComponent } from './shared/Nav/Nav.component';


import { AppRoutingModule } from './app-routing.module';

import { BunissesAreaService } from './services/bunissesArea.service';
import { MarketAreaService } from './services/marketArea.service';
import { OperitingUnitsService } from './services/operitingUnits.service';
import { TechnologicalAreaService } from './services/technologicalArea.service';

import { DateFormatPipe } from './helpers/DateFormat.pipe';

import { MarketAreaComponent } from './components/market-area/market-area.component';
import { TechnologicalareaComponent } from './components/technologicalarea/technologicalarea.component';
import { OperitingunitsComponent } from './components/operitingunits/operitingunits.component';
import { OrganationalstructureComponent } from './components/organationalstructure/organationalstructure.component';
import { BusinessAreaComponent } from './components/business-area/business-area.component';
import { TituloComponent } from './shared/titulo/titulo.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { BusinessAreaDetalhesComponent } from './components/business-area/business-area-detalhes/business-area-detalhes.component';
import { BusinessAreaListaComponent } from './components/business-area/business-area-lista/business-area-lista.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { MarketAreaListaComponent } from './components/market-area/market-area-lista/market-area-lista.component';
import { MarketAreaDetalhesComponent } from './components/market-area/market-area-detalhes/market-area-detalhes.component';
import { OperitingunitsaListaComponent } from './components/operitingunits/operitingunits-lista/operitingunitsa-lista.component';
import { OperitingunitsDetalhesComponent } from './components/operitingunits/operitingunits-detalhes/operitingunits-detalhes.component';
import { TechnologicalareaListaComponent } from './components/technologicalarea/technologicalarea-lista/technologicalarea-lista.component';
import { TechnologicalareaDetalhesComponent } from './components/technologicalarea/technologicalarea-detalhes/technologicalarea-detalhes.component';



@NgModule({
  declarations: [
    AppComponent,
    BusinessAreaComponent,
    MarketAreaComponent,
    OperitingunitsComponent,
    OrganationalstructureComponent,
    TechnologicalareaComponent,
    NavComponent,
    TituloComponent,
    DashboardComponent,
    PerfilComponent,
    DateFormatPipe,
    BusinessAreaDetalhesComponent,
    BusinessAreaListaComponent,
    UserComponent,
    LoginComponent,
    RegistrationComponent,
    MarketAreaListaComponent,
    MarketAreaDetalhesComponent,
    OperitingunitsaListaComponent,
    OperitingunitsDetalhesComponent,
    TechnologicalareaListaComponent,
    TechnologicalareaDetalhesComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot(),
    BsDatepickerModule.forRoot(),
    NgxSpinnerModule
  ],
  providers: [
    BunissesAreaService,
    MarketAreaService,
    OperitingUnitsService,
    TechnologicalAreaService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
