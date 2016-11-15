var gulp = require('gulp');
var connect = require('gulp-connect');
var jshint = require('gulp-jshint');
var less = require('gulp-less');
var concatCss = require('gulp-concat-css');
var minifyCss = require('gulp-minify-css');

var paths = {
    distDev: './dist.dev',
    distProd: './dist.prod',

    lint: ['./src/app/**/*.js', './src/assets/js/**/*.js', '!./src/assets/libs/**'],
    styles: [
        './src/assets/libs/bootstrap/less/bootstrap.less',
        './src/assets/styles/**/*.css', 
        './src/assets/styles/**/*.less'
    ]
};

gulp.task('lint', function () {
   gulp.src(path.lint)
    .pipe(jshint())
    .pipe(jshint.reporter('default'))
    .pipe(jshint.reporter('fail'));
});

gulp.task('styles-dev', function(){
     return gulp.src(paths.styles)
        .pipe(less())
        .pipe(concatCss('styles/bundle.css'))
        .pipe(gulp.dest(paths.distDev));
});

gulp.task('styles-prod', function(){
    return gulp.src(paths.styles)
        .pipe(less())
        .pipe(concatCss('styles/bundle.css'))
        .pipe(minifyCss())
        .pipe(gulp.dest(paths.distProd));
});

gulp.task('build', ['lint', 'styles-dev']);

gulp.task('build-prod', ['lint', 'styles-prod']);