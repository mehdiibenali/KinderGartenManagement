import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FrameworkRoutingModule } from './framework-routing.module';
import { AddEleveComponent } from './eleve/add-eleve/add-eleve.component';
import { EditEleveComponent } from './eleve/edit-eleve/edit-eleve.component';
import { NbLayoutModule, NbSidebarModule, NbButtonModule, NbContextMenuModule, NbMenuModule, NbUserModule, NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbTabsetModule, NbSpinnerModule, NbOptionModule, NbDialogModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AddParentComponent } from './parent/add-parent/add-parent.component';
import { EditParentComponent } from './parent/edit-parent/edit-parent.component';
import { AddConventionComponent } from './Convention/add-convention/add-convention.component';
import { AddPayementComponent } from './Payement/add-payement/add-payement.component';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { PayementRecapComponent } from './Payement/payement-recap/payement-recap.component';
import { PayementenrollementsComponent } from './Payement/payementenrollements/payementenrollements.component';
import { AddClubComponent } from './club/add-club/add-club.component';
import { AddGroupeComponent } from './groupe/add-groupe/add-groupe.component';



@NgModule({
  declarations: [AddEleveComponent, EditEleveComponent, AddParentComponent, EditParentComponent, AddConventionComponent, AddPayementComponent, PayementRecapComponent, PayementenrollementsComponent, AddClubComponent, AddGroupeComponent],
  imports: [
    CommonModule,
    FrameworkRoutingModule,
    NbLayoutModule,
    NbSidebarModule, // NbSidebarModule.forRoot(), //if this is your app.module
    NbButtonModule,
    NbContextMenuModule,
    NbMenuModule,
    NbUserModule,
    NbCardModule,
    NbSelectModule,
    NbIconModule,
    NbAlertModule,
    NbInputModule,
    RouterModule,
    FormsModule,
    NbTabsetModule,
    NbSpinnerModule,
    NbEvaIconsModule,
    NbDialogModule.forRoot(),
  ],
  exports:[AddEleveComponent, EditEleveComponent, AddParentComponent,EditParentComponent,AddConventionComponent,AddPayementComponent,AddGroupeComponent,AddClubComponent]
})
export class FrameworkModule { }
