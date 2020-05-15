import { Component, TemplateRef } from '@angular/core';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { VersionsClient,CreateVersionCommand,VersionVM, VersionDto} from '../audit-api';

@Component({
    selector: 'app-version-component',
    templateUrl:'./version.component.html',
    styleUrls:['./version.component.css']
})
export class VersionComponent {

}