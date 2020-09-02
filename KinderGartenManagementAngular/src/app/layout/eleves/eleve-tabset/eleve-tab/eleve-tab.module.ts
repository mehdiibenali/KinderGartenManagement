import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EleveTabRoutingModule } from './eleve-tab-routing.module';
import { AddEleveTeComponent } from './add-eleve-te/add-eleve-te.component';
import { EditEleveTeComponent } from './edit-eleve-te/edit-eleve-te.component';
import { FrameworkModule } from 'src/app/framework/framework.module';

@NgModule({
  declarations: [AddEleveTeComponent, EditEleveTeComponent],
  imports: [
    CommonModule,
    EleveTabRoutingModule,
    FrameworkModule
    ]
})
export class EleveTabModule { }
