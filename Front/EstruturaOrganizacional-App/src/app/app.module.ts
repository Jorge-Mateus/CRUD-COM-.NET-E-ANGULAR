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
import { NavComponent } from './Nav/Nav.component';
import { BusinessAreaComponent } from './business-area/business-area.component';
import { MarketAreaComponent } from './market-area/market-area.component';

import { AppRoutingModule } from './app-routing.module';

import { BunissesAreaService } from './services/bunissesArea.service';

import { DateFormatPipe } from './helpers/DateFormat.pipe';



@NgModule({
  declarations: [
    AppComponent,
    BusinessAreaComponent,
    MarketAreaComponent,
    NavComponent,
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
