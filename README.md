Test task in style of potion craft game Potion Craft with additional tasks made(1, 2, 3, 4, 9, 11,12) https://drive.google.com/file/d/1wSuabRMrVOvtwMHojfGGRRffd1tap_kr/view?pli=1

Game core architechture is base on Decorator pattern: every bussiness logic feature should have interface(IFeature), basic model implemenetation Feature: IFeature, all subsequent horizintal layers of application (on scene visual, audio, logging etc) have to implement same interface and delegate call next to implementation. This approach allows to build scalable code and allows to moq and test any feature.

