import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

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
import { MarketAreaComponent } from './components/market-area/market-area.component';

import { DateFormatPipe } from './helpers/DateFormat.pipe';

import { TechnologicalareaComponent } from './components/technologicalarea/technologicalarea.component';
import { OperitingunitsComponent } from './components/operitingunits/operitingunits.component';
import { OrganationalstructureComponent } from './components/organationalstructure/organationalstructure.component';
import { BusinessAreaComponent } from './components/business-area/business-area.component';
import { TituloComponent } from './shared/titulo/titulo.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';



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
    DateFormatPipe
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot(),
    NgxSpinnerModule
  ],
  providers: [
    BunissesAreaService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
