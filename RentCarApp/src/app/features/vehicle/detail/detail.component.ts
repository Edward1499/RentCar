import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, switchMap, tap } from 'rxjs/operators';
import { VehicleService } from '../services/vehicle.service';
import { Gallery, GalleryItem, ImageItem, ThumbnailsPosition, ImageSize } from 'ng-gallery';
import { Lightbox } from 'ng-gallery/lightbox';
import { BrandService } from '../../brand/services/brand.service';
import { ModelService } from '../../model/services/model.service';
import { VehicleTypeService } from '../../vehicle-type/services/vehicle-type.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CompleteTransactionComponent } from '../components/complete-transaction/complete-transaction.component';
import { ToastrService } from 'ngx-toastr';
import { DeleteModalComponent } from 'src/app/shared/components/delete-modal/delete-modal.component';

const data = [
  {
    srcUrl: 'https://preview.ibb.co/jrsA6R/img12.jpg',
    previewUrl: 'https://preview.ibb.co/jrsA6R/img12.jpg'
  },
  {
    srcUrl: 'https://preview.ibb.co/kPE1D6/clouds.jpg',
    previewUrl: 'https://preview.ibb.co/kPE1D6/clouds.jpg'
  },
  {
    srcUrl: 'https://preview.ibb.co/mwsA6R/img7.jpg',
    previewUrl: 'https://preview.ibb.co/mwsA6R/img7.jpg'
  },
  {
    srcUrl: 'https://preview.ibb.co/kZGsLm/img8.jpg',
    previewUrl: 'https://preview.ibb.co/kZGsLm/img8.jpg'
  }
];

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {

  vehicle: any;

  items!: GalleryItem[];
  imageData = data;

  constructor(
    private activatedRoute: ActivatedRoute,
    private vehicleService: VehicleService,
    public gallery: Gallery, 
    public lightbox: Lightbox,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.pipe(
      switchMap(({id}) => this.vehicleService.get(id)),
      tap(response => {
        this.vehicle = response;
        this.items = this.vehicle.images.map((item: any) => new ImageItem({ src: item.imageUrl, thumb: item.imageUrl }))
        console.log(response)
      })
    ).subscribe();

    // Get a lightbox gallery ref
    const lightboxRef = this.gallery.ref('lightbox');

    // Add custom gallery config to the lightbox (optional)
    lightboxRef.setConfig({
      imageSize: ImageSize.Cover,
      thumbPosition: ThumbnailsPosition.Top,
    });

    // Load items into the lightbox gallery ref
    lightboxRef.load(this.items);
  }

  onComplete() {
    this.modalService.open(CompleteTransactionComponent, { ariaLabelledBy: 'modal-basic-title' }).result
      .then(_ => {}
      ,(reason) => {
        if (reason === 'complete') {
          this.vehicleService.completeTransaction(this.vehicle.id)
            .subscribe(() => {
              this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
              this.router.navigate(['/vehiculos']);
            });
        }
      });
  }

  onRemove() {
    this.modalService.open(DeleteModalComponent, { ariaLabelledBy: 'modal-basic-title' }).result
      .then(_ => {}
      ,(reason) => {
        if (reason === 'remove') {
          this.vehicleService.delete(this.vehicle.id)
            .subscribe(() => {
              this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
              this.router.navigate(['/vehiculos']);
            });
        }
      });
  }

}
