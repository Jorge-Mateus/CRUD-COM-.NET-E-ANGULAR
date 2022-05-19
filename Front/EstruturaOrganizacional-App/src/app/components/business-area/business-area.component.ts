import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BusinessArea } from 'src/app/model/BusinessArea';
import { BunissesAreaService } from 'src/app/services/bunissesArea.service';



@Component({
  selector: 'app-business-area',
  templateUrl: './business-area.component.html',
  styleUrls: ['./business-area.component.scss']
})
export class BusinessAreaComponent implements OnInit {
 ngOnInit(): void {
 }


}
