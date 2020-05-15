import { Component, TemplateRef } from '@angular/core';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { FashionVM, FashionDto, FashionsClient, CreateFashionCommand } from '../audit-api';

@Component({
    selector: 'app-fashion-component',
    templateUrl: './fashion.component.html',
    styleUrls:['./fashion.component.css']
})
export class FashionComponent{
    vm: FashionVM;

    newFashionEditor: any= {};

    newFashionModalRef: BsModalRef;

    faPlus=faPlus;
    

    constructor(private listsClient: FashionsClient, private modalService: BsModalService){
        listsClient.get().subscribe(
            result => {
                this.vm = result;
            }
        )
    }

    showNewListModal(template: TemplateRef<any>): void {
        this.newFashionModalRef = this.modalService.show(template);
        setTimeout(() => document.getElementById("name").focus(),250);
    }

    newFashionCancelled(): void{
        this.newFashionModalRef.hide();
        
    }
    addFashion():void{
        let list = FashionDto.fromJS({
            id:null,
            name: this.newFashionEditor.name
        });

        this.listsClient.create(<CreateFashionCommand>{name:this.newFashionEditor.name})
        .subscribe(
            result => {
                list.id = result;
                this.vm.lists.push(list);
                this.newFashionModalRef.hide();
                this.newFashionEditor={};
            },error => {
                let errors = JSON.parse(error.response);
                if(errors && errors.Title){
                    this.newFashionEditor.error = errors.errors.Name[0];
                }
                setTimeout(() => document.getElementById("name").focus(), 250);
            }
        );
    }
    
}