import { Component, TemplateRef } from '@angular/core';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import {ProductTypeDto, ProductTypeVm, CreateProductTypeCommand, ProductTypesClient} from '../audit-api';

@Component({
    selector: 'app-productType-component',
    templateUrl: './product-type.component.html',
    styleUrls:['./product-type.component.css']
})
export class ProductTypeComponent {
    vm: ProductTypeVm;

    newProductTypeEditor: any ={};
    newProductModalRef: BsModalRef;
    faPlus=faPlus;


    constructor(private listsClient: ProductTypesClient, private modalService: BsModalService) {
        listsClient.get()
        .subscribe(
            result => {
                this.vm = result;
            }
        )
    }

    showNewListModal(template: TemplateRef<any>): void {
        this.newProductModalRef =  this.modalService.show(template);
        setTimeout(() => document.getElementById("name").focus(),250);
    }

    newProductTypeCancelled():void{
        this.newProductModalRef.hide();
    }

    addProductType():void {
        let list = ProductTypeDto.fromJS({
            id:null,
            name: this.newProductTypeEditor.name
        });

        this.listsClient.create(<CreateProductTypeCommand>{name:this.newProductTypeEditor.name})
        .subscribe(
            result => {
                list.id = result;
                this.vm.lists.push(list);
                this.newProductModalRef.hide();
                this.newProductTypeEditor={};
            }, error => {
                let errors = JSON.parse(error.response);
                if(errors && errors.title){
                    this.newProductTypeEditor.error = errors.errors.Name[0];
                }
                setTimeout(() => document.getElementById("name").focus(), 250);
            }
        )
    }
}